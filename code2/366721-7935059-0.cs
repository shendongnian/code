	public sealed class Create : Activity
    {
        public Create()
        {
            Implementation = new Func<Activity>(CreateBody);
        }
        public string ServiceContract { get; set; }
        public string Operation { get; set; }
        [RequiredArgument]
        public InArgument<CorrelationHandle> CorrelationHandle { get; set; }
        Activity CreateBody()
        {
            // variables declaration. 
            var operationRequestParam = new Variable<OperationRequestParam>();
            var appData = new Variable<ApplicationDataList>();
            var operationResponseParam = new Variable<OperationResponseParam>();
            var correlationKey = new Variable<string>();
            Receive receiveRequest;
            return new Sequence
            {
                Variables = { correlationKey }, 
                Activities = 
				{
                    {receiveRequest = new Receive()
                    {
                        ServiceContractName = ServiceContract,
                        OperationName = Operation,
                        CanCreateInstance = true,
                        //parameters for receive
                        Content = new ReceiveMessageContent
                        {
                            Message = new OutArgument<string>(ctx => operationRequestParam.Get(ctx))
                        },
                    }},
                    // Assign a unique identifier to the correlation key.
                    new Assign<string>
                    {
                        To = new OutArgument<string>(ctx => correlationKey.Get(ctx)),
                        Value = new InArgument<string>(ctx => Guid.NewGuid().ToString())
                    },
                    new Assign<OperationResponseParam>
                    {
                        To = new OutArgument<OperationResponseParam>(ctx => operationResponseParam.Get(ctx)),
                        Value = new InArgument<OperationResponseParam>
                        {
                            Expression = new BuildResponse()
                            {
                                CorrelationKey = new InArgument<string>(correlationKey),
                            }
                        }
                    },
                    new SendReply
                    {
                        Request = receiveRequest,
                        Content = new SendMessageContent
                        {
                            Message = new InArgument<string>(ctx => operationResponseParam.Get(ctx))
                        },
                        CorrelationInitializers =
                        {
                            new QueryCorrelationInitializer
                            {
                                CorrelationHandle =  new InArgument<CorrelationHandle>(ctx => CorrelationHandle.Get(ctx)),
                                MessageQuerySet = new MessageQuerySet
                                {
                                    {
                                        "CorrelationKey", new XPathMessageQuery("sm:header()/tempuri:CorrelationKey")
                                    }
                                }
                            }
                        }
                    },
				}
            };
        }
    }
	
	public sealed class Wait : Activity
    {
        static Wait()
        {
            AttributeTableBuilder builder = new AttributeTableBuilder();
            builder.AddCustomAttributes(typeof(Wait), "EscalationData", new EditorAttribute(typeof(EscalationDataEditor), typeof(DialogPropertyValueEditor)));
            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
        public Wait()
        {
            Implementation = new Func<Activity>(CreateBody);
        }
        public EscalationInfoList EscalationData { get; set; }
        public string ServiceContract { get; set; }
        public string Operation { get; set; }
        [RequiredArgument]
        public InArgument<CorrelationHandle> CorrelationHandle { get; set; }
        Activity CreateBody()
        {
            // variables declaration. 
            var appData = new Variable<ApplicationDataList>();
            var operationRequestParam = new Variable<OperationRequestParam>();
            var operationResponseParam = new Variable<OperationResponseParam>();
            Receive receiveRequest;
            return new Sequence
            {
                Activities =
                {
				   new Sequence
				   {
						Variables = {operationRequestParam, operationResponseParam },
						Activities = 
						{
							{receiveRequest =new Receive()
							{
								ServiceContractName = ServiceContract,
								OperationName = Operation,
								CanCreateInstance = false,
								CorrelatesWith = new InArgument<CorrelationHandle>(ctx => CorrelationHandle.Get(ctx)),
								CorrelatesOn = new MessageQuerySet
								{
									{ "CorrelationKey", new XPathMessageQuery("sm:header()/tempuri:CorrelationKey")}
								},
								//parameters for receive
								Content = new ReceiveMessageContent
								{
									Message = new OutArgument<OperationRequestParam>(ctx => operationRequestParam.Get(ctx))
								},
							}},
							new SendReply
							{
								Request = receiveRequest,
								Content = new SendMessageContent
								{
									Message = new InArgument<OperationResponseParam>(ctx => operationResponseParam.Get(ctx))
								}
							},
						}
					},
				}
			}
		}
	}

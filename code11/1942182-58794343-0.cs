      class RequestProxy :
            RoutingSlipRequestProxy<Request>
        {
            protected override void BuildRoutingSlip(RoutingSlipBuilder builder, ConsumeContext<Request> request)
            {
            // get configs
            var settings = new Settings(_configuration);
            // Add activities
            builder.AddActivity(settings.CreateOrderActivityName, settings.CreateOrderExecuteAddress);
            builder.SetVariables(new { context.Message.OrderId, context.Message.Address, context.Message.CreatedDate, context.Message.OrderDetails });
            builder.AddActivity(settings.ReserveProductActivityName, settings.ReserveProductExecuteAddress);
            builder.SetVariables(new { context.Message.OrderDetails });
            }
        }
        class ResponseProxy :
            RoutingSlipResponseProxy<Request, Response>
        {
            protected override Response CreateResponseMessage(ConsumeContext<RoutingSlipCompleted> context, Request request)
            {
                return new Response();
            }
        }

     public static void ReturnOperationsParameters(string fileName)
        {
            var reader = new XmlTextReader(fileName);
            var serviceDescription = ServiceDescription.Read(reader);
            BindingCollection bindColl = serviceDescription.Bindings;
            PortTypeCollection portTypColl = serviceDescription.PortTypes;
            MessageCollection msgColl = serviceDescription.Messages;
            Types typs = serviceDescription.Types;
            foreach (Service service in serviceDescription.Services)
            {
                String webServiceNmae = service.Name.ToString();
                foreach (Port port in service.Ports)
                {
                    string portName = port.Name;
                    string binding = port.Binding.Name;
                    System.Web.Services.Description.Binding bind = bindColl[binding];
                    PortType portTyp = portTypColl[bind.Type.Name];
                    foreach (Operation op in portTyp.Operations)
                    {
                        var operatioList = new SoapData();
                       // _soapdata = new SoapData();
                        OperationMessageCollection opMsgColl = op.Messages;
                        OperationInput opInput = opMsgColl.Input;
                        string inputMsg = opInput.Message.Name;
                        Message msgInput = msgColl[inputMsg];
                        MessagePart part = msgInput.Parts[0];
                        operatioList.OperationName = op.Name;
                        operatioList.NameSpace = part.Element.Namespace;
                        TreeItemSource.Add(operatioList);
                    }
                }
            }
        }
    }
    public class SoapData
    {
        public int Id { get; set; }
        public string RequestXml { get; set; }
        public string ResponseXml { get; set; }
        public string NameSpace { get; set; }
        public string OperationName { get; set; }
    }

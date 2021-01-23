    using (new System.ServiceModel.OperationContextScope((System.ServiceModel.IContextChannel)base.Channel))
        {
            m_lastMessageId = new System.Xml.UniqueId();
            System.ServiceModel.OperationContext.Current.OutgoingMessageHeaders.MessageId = m_lastMessageId;
            // call here the request
        }

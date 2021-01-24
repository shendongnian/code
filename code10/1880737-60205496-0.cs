    TransmissionService transmission = new TransmissionService();
    using (new OperationContextScope((IContextChannel) transmission))
    {
        OperationContext.Current.OutgoingMessageHeaders.Add(
            new SecurityHeader("UsernameToken-8", "12345/userID", "password123"));
        transmission.publish(new Transmission());
    }

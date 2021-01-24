            service.OnSerializeCustomSoapHeaders += service_OnSerializeCustomSoapHeaders;
            appointment.Update(ConflictResolutionMode.AlwaysOverwrite, SendInvitationsOrCancellationsMode.SendToAllAndSaveCopy);
            service.OnSerializeCustomSoapHeaders -= service_OnSerializeCustomSoapHeaders;
        static void service_OnSerializeCustomSoapHeaders(XmlWriter writer)
        {
            writer.WriteRaw(Environment.NewLine + "    <t:TimeZoneContext><t:TimeZoneDefinition Id=\"" + TimeZone.CurrentTimeZone.StandardName + "\"/></t:TimeZoneContext>" + Environment.NewLine);
        }

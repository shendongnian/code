    public class MyTextMessage : TextMessage
    {
        protected override SubmitSm CreateSubmitSm(SmppEncodingService smppEncodingService)
        {
            var sm = base.CreateSubmitSm(smppEncodingService);
            sm.SourceAddress.Ton = JamaaTech.Smpp.Net.Lib.TypeOfNumber.Aphanumeric;
            sm.SourceAddress.Npi = JamaaTech.Smpp.Net.Lib.NumberingPlanIndicator.Unknown;
            return sm;
        }
    }

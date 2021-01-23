	public class AppTextExceptionFormatter : TextExceptionFormatter
	{
        public AppTextExceptionFormatter(TextWriter writer, 
                 Exception exception, 
                 Guid handlingInstanceId)
			: base (writer, exception, handlingInstanceId) 
		{
            if (exception is System.Net.WebException) 
            {
                AdditionalInfo.Add("Status", ((System.Net.WebException)exception).Status.ToString());
            }
            else if (exception is System.Web.Services.Protocols.SoapException)
            {
                AdditionalInfo.Add("Actor", ((SoapException)exception).Actor);
            } 
	    }
    }

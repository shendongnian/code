    public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        Hl7.Fhir.Serialization.FhirJsonSerializer ser = new Hl7.Fhir.Serialization.FhirJsonSerializer();
        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(context.HttpContext.Response.Body))
        {
            using (Newtonsoft.Json.JsonWriter jw= new Newtonsoft.Json.JsonTextWriter(sw))
            {
                ser.Serialize((Hl7.Fhir.Model.Base)context.Object, jw);
            }
        }
        return Task.CompletedTask;
    }

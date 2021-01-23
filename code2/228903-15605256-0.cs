        [System.Obsolete("ObjectDump should not be included in production code.")]
        public static void Dump(this object value)
        {
            try
            {
                System.Diagnostics.Trace.WriteLine(JsonConvert.SerializeObject(value, Formatting.Indented));
            }
            catch (Exception exception)
            {
                System.Diagnostics.Trace.WriteLine("Object could not be formatted. Does it include any interfaces? Exception Message: " + exception.Message);
            }
        }
    

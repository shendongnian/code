    public static class JSON{
          public static string ToJavaScriptObject(this object @object){
              var jobject =  JObject.FromObject(@object).ToString();
              jobject = jobject.Substring(1);
              jobject = jobject.Substring(0,jobject.Length-1);
              return jobject;
          }
    }

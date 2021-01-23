    using System.Reflection;
    public class ResponseWrapper {
    
      public static ConfigurationData GetConfiguration( Request request, Type dtype  )
      {
        // build the type at runtime
        Type chtype = typeof(GetConfigurationSettingMessgeResponse<>);
        Type gchtype = chtype.MakeGenericType( new Type[] { dtype } );
        
        // create an instance. Note, you'll have to know about your 
        // constructor args in advance. If the consturctor has no 
        // args, use Activator.CreateIntsance.
        // new GetConfigurationSettingMessageResponse<gchtype>
        object ch = Activator.CreateInstance(gchtype); 
        // now invoke SendSingleMessage ( assuming MessagingClient is a 
        // static class - hence first argument is null. 
        // now pass in a reference to our ch object.
        MethodInfo sendsingle = typeof(MessagingClient).GetMethod("SendSingleMessage");        
        sendsingle.Invoke( null, new object[] { request, ref ch } );
        // we've successfulled made the call.  Now return ConfigurtationData
        // find the property using our generic type
        PropertyInfo chcd = gchtype.GetProperty("ConfigurationData");
        // call the getter.
        object data = chcd.GetValue( ch, null );
        // cast and return data
        return data as ConfigurationData;
      }
    }

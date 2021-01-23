    using System.Web.Script.Serialization;
    
    ...
    
    var jsSerializer = new JavaScriptSerializer();
    string jsDate = jsSerializer.Serialize(appointment.AppointmentDate);

    namespace Project.Web.Models
    {
        public interface IDevice
        {
            int ID { get; set; }
        }
    }
    
    namespace Some.Namespace // copy the name from the auto-generated file
    {
        public partial class SwitchDevice : Project.Web.Models.IDevice
        {
        }
    }

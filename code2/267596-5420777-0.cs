    public class PageGeneratorWidget
    {
        public ColorPickerWidget com1 { get; protected set; } 
    
        public PageGeneratorWidget(string dataId){
         //SOME CODE LIKE
         //com1.Type = "flat";
        com1 = new ColorPickerWidget(); // Use color Picker Widget constructor
        }
    }

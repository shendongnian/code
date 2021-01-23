     public interface ICheckable
        {
            bool Checked { get; set; }
        }
        class RadioButtonExtended : RadioButton,ICheckable
        {
           
        }
        class CheckBoxExtended : CheckBox, ICheckable
        { 
        }

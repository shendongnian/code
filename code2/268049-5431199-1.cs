    public class CustomerEditor
    {
        public DateTime? Birthday
        {
            get
            {
                //probably tryparse but you get the idea
                return DateTime.Parse(birthdayPickerTextBox.Text); 

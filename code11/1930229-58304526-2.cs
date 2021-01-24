        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
            public void SetPersonalInformation(PersonalInformation value)
            {
                placeOfApplictionLabel.Text = value.PlaceOfApplication;
                genderLabel.Text = value.Gender;
            }
        }

        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            public PersonalInformation PersonalInformation
            {
                get
                {
                    return new PersonalInformation()
                    {
                        PlaceOfApplication = placeOfApplicationTextBox.Text,
                        Gender = genderTextBox.Text
                    };
                }
                set
                {
                    placeOfApplicationTextBox.Text = value.PlaceOfApplication;
                    genderTextBox.Text = value.Gender;
                }
            }
        }

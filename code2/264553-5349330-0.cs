        public class CustomResource: Telerik.Windows.Controls.Resource
        {
            private int noOfAppointments;
            public int NoOfAppointments
            {
                get { return noOfAppointments; }
                set
                {
                    if (value > 0)
                        noOfAppointments = value;
                    else
                        noOfAppointments = 0;
                }
            }
        }

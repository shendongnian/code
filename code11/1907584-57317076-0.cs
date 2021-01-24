    partial class Model
    {
        [NotMapped]
        public bool FieldABool
        {
            get
            {
                return FieldA == "TRUE";
            }
            set
            {
                if (value == true)
                {
                        FieldA = "TRUE";
                }         
                else
                {
                    FieldA = "FALSE";
                }
            }
        }
    }

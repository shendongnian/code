    [TypeConverter(typeof(MyEnumConverter))]
    public enum AgencyTypes {
        [System.ComponentModel.Description("Mental Health")]
        MentalHealth,
        Corrections,
        [System.ComponentModel.Description("Drug & Alcohol")]
        DrugAndAlcohol,
        Probation
    }

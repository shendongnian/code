    public class ClassTest_FCT_Extern
    {
        public bool TestAvailable
        {
            get { return ClassTest.abTestAvailable[(int)ClassTest.IndividualTest.FCT_Extern]; }
            set { ClassTest.abTestAvailable[(int)ClassTest.IndividualTest.FCT_Extern] = value; }
        }

        public class SomeObject
        { }
        public static List<T> MyFunction<T>(List<T> listaCompleta, int numeroPacchetti)
        {
            return listaCompleta;
        }
        static void Main(string[] args)
        {
            var someObjects = new List<SomeObject>();
            var listPacchetti = (from SomeObject myso in someObjects
                                               select myso).ToList();
            listPacchetti =  MyFunction<SomeObject>(listPacchetti, 1);
        }

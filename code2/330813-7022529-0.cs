        public class SomeObject
        { }
        public static IList<T> MyFunction<T>(IList<T> listaCompleta, int numeroPacchetti)
        {
            return listaCompleta;
        }
        static void Main(string[] args)
        {
            var someObjects = new List<SomeObject>();
            var listPacchetti = (from SomeObject myso in someObjects
                                               select myso).ToList();
            listPacchetti =  (List<SomeObject>) MyFunction(listPacchetti, 1);
        }

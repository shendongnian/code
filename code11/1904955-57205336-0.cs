    class Program
    {
        static void Main(string[] args)
        {
            int maxNum = 10;
            string initialString = "a<b<c<d<e<f<g<h<i<j<k<l<m<n<o<p<q<r<s<t<u<v<w<x<y<z";
            string[] splitString = initialString.Split('<');
            string result = "";
            Console.WriteLine(splitString.Length);
            if (splitString.Length > maxNum)
            {
                for (int i = 0; i < maxNum; i++) {
                    result += splitString[i];
                    result += "<";
                }
            }
            else
            {
                result = initialString;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }

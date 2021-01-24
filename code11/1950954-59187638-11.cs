    class Program
    {
        static void Main(string[] args)
        {            
            string bankATransJson = GetBankATestJsonInput();
            BankATransaction bankATransaction = JsonConvert.DeserializeObject<BankATransaction>(bankATransJson);
            BankA bankA = new BankA();
            bankA.Transaction = bankATransaction;
            Console.WriteLine(SaveBank(bankA));
            // output:
            // {
            // "BankName": "BankA",
            // "GROUPName": "g54321",
            // "ACC_ID": "A01",
            // "ACCOUNT_NO": "A1111"
            // }
            string bankBInputJson = GetBankBTestJsonInput();
            BankBTransaction bankBTransInput = JsonConvert.DeserializeObject<BankBTransaction>(bankBInputJson);
            BankB bankB = new BankB();
            bankB.Transaction = bankBTransInput;
            Console.WriteLine(SaveBank(bankB));
           // output:
           // {
           // "BankName": "BankB",
           // "ACC_ID": "B02",
           // "ACCOUNT_NO": "B2222",
           // "Name": "Bank_Of_B           
           // }
            string bankCInputJson = GetBankCTestJsonInput();
            BankCTransaction bankCTransInput = JsonConvert.DeserializeObject<BankCTransaction>(bankCInputJson);
            BankC bankC = new BankC();
            bankC.Transaction = bankCTransInput;
            Console.WriteLine(SaveBank(bankC));
            // output:
            // {
            // "BankName": "BankC",
            // "ACC_ID": "C03",
            // "ACCOUNT_NO": "C3333",
            // "FullName": "C Bank"
            // }
        }
        public static string SaveBank(IBankData bankData)
        {
            // when calling the serialize object method, we pass our BankJsonConverter
            string jsonText = JsonConvert.SerializeObject(bankData, Formatting.Indented, new BankJsonConverter());
            // this example just returns the JSON text
            // but you would implement your save logic as needed
            return jsonText;
        }
        private static string GetBankATestJsonInput()
        {
            var obj = new { ACC_ID = "A01", ACCOUNT_NO = "A1111", GROUPName = "g54321" };
            return JsonConvert.SerializeObject(obj);
        }
        private static string GetBankBTestJsonInput()
        {
            var obj = new { ACC_ID = "B02", ACCOUNT_NO = "B2222", Name = "Bank_Of_B" };
            return JsonConvert.SerializeObject(obj);
        }
        private static string GetBankCTestJsonInput()
        {
            var obj = new { ACC_ID = "C03", ACCOUNT_NO = "C3333", FullName = "C Bank" };
            return JsonConvert.SerializeObject(obj);
        }
    }

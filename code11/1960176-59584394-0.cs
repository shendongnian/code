        class Program
    {
        private static void Main(string[] args)
        { 
            // Get JSON from URL
            var json = GetJasonFromUrl(Properties.Settings.Default.url);
            // De-serialize JSON into a list
            var deserlizedJson = DeserializeMyJson(json);
            // Go through each item in the list and determine if palindrome or not
            foreach (var item in deserlizedJson)
            {
                if (IsPalindrome(item.Str))
                    Console.WriteLine(item.Str + " is palindrome");
                else
                    Console.WriteLine(item.Str + " is not palindrome");
            }
        }
        private static string GetJasonFromUrl(string url)
        {
            string result;
            try
            {
                using (var webClient = new WebClient())
                {
                    result = webClient.DownloadString(url);
                }
            }
            catch (Exception)
            {
                result = string.Empty;
            }
            return result;
        }
        private static IEnumerable<Palindromes> DeserializeMyJson(string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Palindromes>>(json);
        }
        // Assuming your function is tested and correct
        private static bool IsPalindrome(string value)
        {
            var min = 0;
            var max = value.Length - 1;
            while (true)
            {
                if (min > max)
                    return true;
                var a = value[min];
                var b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                    return false;
                min++;
                max--;
            }
        }
    }
    internal class Palindromes
    {
        public string Str { get; set; } = string.Empty;
        public bool Result { get; set; } = false;
    }

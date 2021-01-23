        bool Clear(string str, out string res)
        {
            var ind = str.IndexOf("[[[\"");
            if (ind == -1)
            {
                res = "";
                return false;
            }
            int end = str.IndexOf("[\"\",,,", ind + 1);
            if (end == -1)
            {
                res = "";
                return false;
            }
            res = str.Substring(ind + 2, end - ind);
            var arr = res.Split(new[] {"\",\"", "\"],[\"", "[\"", "\"]"}, StringSplitOptions.RemoveEmptyEntries);
            res = "";
            for (int i = 0; i < arr.Length; i += 2)
            {
                res += arr[i];
            }
            return true;
        }
        void TranslateText(string src_lang, string dst_lang)
        {
            var input = "Some request text";
            var url = String.Format("https://translate.google.ru/translate_a/single?client=t&sl={0}&tl={1}&hl={1}&dt=bd&dt=ex&dt=ld&dt=md&dt=qc&dt=rw&dt=rm&dt=ss&dt=t&dt=at&dt=sw&ie=UTF-8&oe=UTF-8&oc=2&otf=1&trs=1&inputm=1&ssel=0&tsel=0&pc=1&q={2}", src_lang, dst_lang, input);
            var webClient = new WebClient{Encoding = Encoding.UTF8};
            webClient.DownloadStringCompleted += (sender, args) =>
            {
                string res;
                if (args.Error != null)
                {
                    MessageBox.Show(args.Error.Message);
                    stoped = true;
                    return;
                }
                if (Clear(args.Result, out res))
                {
                }
            };
            webClient.DownloadStringAsync(new Uri(url), "your state");
        }

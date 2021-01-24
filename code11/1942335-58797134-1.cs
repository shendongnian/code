            List<string> windowListExtended = new List<string>();
            windowListExtended.Add("HwndWrapper[App.exe;;cda6c3f4-8c87-4b12-8f3d-5322ca90eeex]");
            windowListExtended.Add("HwndWrapper[App.exe;;cadac3f4-8c87-4b12-8q3d-1qwe2ca90eec]");
            windowListExtended.Add("HwndWrapper[App.exe;;c1b6a3s4-8c87-4b12-8f3d-2qw2ca90eeev]");
            var myRegex = new Regex(@"HwndWrapper\[App.exe;;.*?]");
            var resultList = files.Where(x => myRegex.IsMatch(x)).Select(x => x.Split(new[] { ";;","]" }, StringSplitOptions.None)[1]).ToList();
            
            //Now resultList contains => cda6c3f4-8c87-4b12-8f3d-5322ca90eeex, cadac3f4-8c87-4b12-8q3d-1qwe2ca90eec, c1b6a3s4-8c87-4b12-8f3d-2qw2ca90eeev
            foreach (var item in resultList)
            {
                //Do whatever you want
            }

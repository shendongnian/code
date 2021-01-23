    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;
    namespace Word_Ending_Finder
    {
        public partial class Form1 : Form
        {
            private List<string> WordsToFind = new List<string>();
            private List<MySpecialStringStruct> PassagesToSearch = new List<MySpecialStringStruct>();
            public Form1()
            {
                InitializeComponent();
                PassagesToSearch.Add(new MySpecialStringStruct("This is a test passage with a test ending.", 0));
                PassagesToSearch.Add(new MySpecialStringStruct("This is a second test passage with a test ending.", 0));
                PassagesToSearch.Add(new MySpecialStringStruct("This is a third passage that won't match.", 0));
                WordsToFind.Add(@"ing\b");
                WordsToFind.Add(@"\bsecond\b");
                WordsToFind.Add(@"\bgarbage text\b");
            }
            private void bnGo_Click(object sender, EventArgs e)
            {
                txtResults.Text = "";
                string Separator = "------------------------------------------";
                StringBuilder NewText = new StringBuilder();
                foreach (string SearchWord in WordsToFind)
                {
                    NewText.AppendLine(string.Format("Now searching {0}", SearchWord));
                    List<MatchValue> Results = FindPassages(PassagesToSearch, SearchWord);
                    if (Results.Count == 0)
                    {
                        NewText.AppendLine("No Matches Found");
                    }
                    else
                    {
                        foreach (MatchValue ThisMatch in Results)
                        {
                            NewText.AppendLine(string.Format("In passage \"{0}\":", ThisMatch.WhichStringStruct.Passage));
                            foreach (Match M in ThisMatch.MatchesFound)
                            {
                                NewText.AppendLine(string.Format("\t{0}", M.Captures[0].ToString()));
                            }
                        }
                    }
                    NewText.AppendLine(Separator);
                }
                txtResults.Text = NewText.ToString();
            }
            private List<MatchValue> FindPassages(List<MySpecialStringStruct> PassageList, string WhatToFind)
            {
                Regex MatchPattern = new Regex(WhatToFind);
                List<MatchValue> ReturnValue = new List<MatchValue>();
                foreach (MySpecialStringStruct SearchTarget in PassageList)
                {
                    MatchCollection MatchList = MatchPattern.Matches(SearchTarget.Passage);
                    if (MatchList.Count > 0)
                    {
                        MatchValue FoundMatchResult = new MatchValue();
                        FoundMatchResult.WhichStringStruct = SearchTarget;
                        FoundMatchResult.MatchesFound = MatchList;
                        ReturnValue.Add(FoundMatchResult);
                    }
                }
                return ReturnValue;
            }
        }
        public class MatchValue
        {
            public MySpecialStringStruct WhichStringStruct;
            public MatchCollection MatchesFound;
        }
        public struct MySpecialStringStruct
        {
            public string Passage;
            public int Id;
            public MySpecialStringStruct(string passage, int id)
            {
                Passage = passage;
                Id = id;
            }
        }
    }

C#
public string ClearFormatting(SheetsService sheetsService, string spreadsheetId, string sheetName, string range)
        {
            string str = string.Empty;
            try
            {
                GoogleSheetsHelper helper = new GoogleSheetsHelper();
                range = helper.RemoveSheetNameHelper(range);
                string[] strArray = range.Split(':');
                List<Request> requestList = new List<Request>();
                BatchUpdateSpreadsheetRequest body = new BatchUpdateSpreadsheetRequest()
                {
                    Requests = (IList<Request>)requestList
                };
                int sheetId = helper.GetSheetIdHelper(sheetsService, spreadsheetId, sheetName);
                Request request = new Request()
                {
                    RepeatCell = new RepeatCellRequest()
                    {
                        Range = new GridRange()
                        {
                            SheetId = new int?(sheetId),
                            StartColumnIndex = new int?(GoogleSheetsHelper.A1ToColumnHelper(strArray[0]) - 1),
                            StartRowIndex = new int?(GoogleSheetsHelper.A1ToRowHelper(strArray[0]) - 1),
                        },
                     Fields = "*"
                    }
                };
                body.Requests.Add(request);
                BatchUpdateSpreadsheetResponse response = sheetsService.Spreadsheets.BatchUpdate(body, spreadsheetId).Execute();
                str = JsonConvert.SerializeObject(response);
            }
            catch (Exception e)
            {
                str = "Message" + e.Message + Environment.NewLine + Environment.NewLine + "InnerException:  " + e.InnerException + Environment.NewLine + Environment.NewLine + "Data:  " + e.Data + Environment.NewLine + Environment.NewLine + "HelpLink:  " + e.HelpLink + Environment.NewLine + Environment.NewLine + "Source:  " + e.Source + Environment.NewLine + Environment.NewLine + "StackTrace:  " + e.StackTrace + Environment.NewLine + Environment.NewLine + "TargetSite:  " + e.TargetSite + Environment.NewLine + Environment.NewLine;
            }
            return str;
        }
**A1ToRowHelper**
C#
internal static int A1ToRowHelper(string a1)
        {
            string empty = string.Empty;
            string str = a1;
            for (int i = 0; i < str.Length; i++)
            {
                char chr = str[i];
                if (char.IsNumber(chr))
                {
                    empty = string.Concat(empty, chr.ToString());
                }
            }
            return int.Parse(empty);
        }
**A1ToColumnHelper**
C#
internal static int A1ToColumnHelper(string a1)
        {
            string empty = string.Empty;
            string str = a1;
            for (int i = 0; i < str.Length; i++)
            {
                char chr = str[i];
                if (char.IsLetter(chr))
                {
                    empty = string.Concat(empty, chr.ToString());
                }
            }
            if (string.IsNullOrEmpty(a1))
            {
                throw new ArgumentNullException("a1");
            }
            empty = empty.ToUpperInvariant();
            int num = 0;
            for (int i = 0; i < empty.Length; i++)
            {
                char chr1 = empty[i];
                num *= 26;
                num = num + chr1 - 65 + 1;
            }
            return num;
        }
**GetSheetIdHelper**
C#
public int GetSheetIdHelper(SheetsService sheetsService, string spreadsheetId, string sheetName)
        {
            Sheet sheet = sheetsService.Spreadsheets.Get(spreadsheetId).Execute().Sheets.First<Sheet>((Sheet x) => x.Properties.Title.Equals(sheetName));
            int? sheetId = sheet.Properties.SheetId;
            return (sheetId.HasValue ? sheetId.GetValueOrDefault() : 0);
        }

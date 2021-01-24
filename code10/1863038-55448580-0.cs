    protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var tableLayout = FindViewById<TableLayout>(Resource.Id.tableLayout);
            var rowCount = 3;
            var columnCount = 3;
            for (int i = 0; i < rowCount; i++)
            {
                Android.Widget.TableRow row = new Android.Widget.TableRow(this);
                for (int j = 0; j < columnCount; j++)
                {
                    var cell = new TextView(this);
                    cell.SetText("(" + i + ", " + j + ")", TextView.BufferType.Normal);
                    row.AddView(cell);
                }
                tableLayout.AddView(row);
            }
            var charList = new List<string> { "A", "B", "C" };
            
            FindViewById<Button>(Resource.Id.btnRun).Click += delegate
            {
                for (int i = 0; i < rowCount; i++)
                {
                    Android.Widget.TableRow row = (Android.Widget.TableRow)tableLayout.GetChildAt(i);
                    for (int j = 0; j < columnCount; j++)
                    {
                        TextView cell = (TextView) row.GetChildAt(j);
                        Random random = new Random();
                        var num = random.NextInt(charList.Count);
                        cell.SetText(charList[num], TextView.BufferType.Normal);
                    }
                }
            };
        }

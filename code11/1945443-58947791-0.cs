    Range r1 = (Range)RibbonHelper.SharedApplicationInstance.Application.ActiveWindow.RangeFromPoint((int)t.left, (int)t.top);
                    Range r2 = (Range)RibbonHelper.SharedApplicationInstance.Application.ActiveWindow.RangeFromPoint((int)t.right, (int)t.bottom);
                    Range r = RibbonHelper.SharedApplicationInstance.ActiveDocument.Range(r1.Start, r2.Start);
                    
                    Range FullDocRange = RibbonHelper.SharedApplicationInstance.ActiveDocument.Range();
                    if (r2.Start <= 1)
                    {
                        r = FullDocRange;
                    }
                    RibbonHelper.VisibleAreaRange = r;

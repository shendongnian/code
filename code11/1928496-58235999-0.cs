                private void grdAlarmData_Resizecolumns(object sender, GridResizingColumnsEventArgs args)
                {            
                    if(args.Reason == GridResizeCellsReason.DoubleClick)
                    {               
                        GridRangeInfo grid = args.Columns;
                        grdAlarmData.Model.ResizeColumnsToFit(GridRangeInfo.Col(grid.Left), GridResizeToFitOptions.IncludeHeaders);              
                    }
                }

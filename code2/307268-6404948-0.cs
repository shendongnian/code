    var query = context.TimeForm.
                Join(context.CLIENT,
                t => t.CODEID, c => c.CODEID ,
                (t, c) => new
                {
                    PropertyA = t.ColumnA,
                    PropertyB = c.ColumnB                    
                }).Join(context.RATE,
                        b => b.RATEID, r => r.RATEID,
                        (b, r) => new
                        {
                            PropertyC = b.ColumnC,
                            PropertyD = r.ColumnD                            
                        }).Join(context.TASK,
                               x => x.TASKID, t => t.TASKID,
                               (x,t) => new
                               {
                                   PropertyE = x.ColumnE,
                                   PropertyF = t.ColumnF
                               });

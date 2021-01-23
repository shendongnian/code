     // styles
                CellStyle cs = grdData.Styles.Normal;
                cs.Border.Direction = BorderDirEnum.Vertical;
                cs.TextAlign = TextAlignEnum.LeftCenter;
                cs.WordWrap = false;
                cs = grdData.Styles.Add("Data");
                cs.BackColor = SystemColors.Info;
                cs.ForeColor = SystemColors.InfoText;
                cs = grdData.Styles.Add("SourceNode");
                cs.BackColor = Color.Yellow;
                cs.Font = new Font(grdData.Font, FontStyle.Bold);
    
                // outline tree
                grdData.Tree.Column = 0;
                grdData.Tree.Style = TreeStyleFlags.Simple;
                grdData.AllowMerging = AllowMergingEnum.Nodes;
    
                // other
                grdData.AllowResizing = AllowResizingEnum.Columns;
                grdData.SelectionMode = SelectionModeEnum.Cell;
    
                grdData.SuspendLayout();
                grdData.Rows.Fixed = 1;
                //grdData.DataSource = dt;
                grdData.Cols[0].Visible = false;
                grdData.Cols[1].Visible = false;
                if (_ID == 9)
                    grdData[0, 0] = "HCFA-672 Assessment";
                else if (_ID == 10)
                    grdData[0, 0] = "HCFA-802 Assessment";
    
                RcsResidentReporterBL resReportBL = new RcsResidentReporterBL();
                DataTable dt = resReportBL.GetCriteriaQueslkp(_ID, facilityID);
    
                List<QuestionNode> qtree = new List<QuestionNode>();
    
                foreach (DataRow dr in dt.Rows)
                {
                    QuestionNode parentNode = new QuestionNode();
                    parentNode.QuestionCode = Convert.ToDecimal(dr["QuestionCode"]);
                    parentNode.AssessmentSection = dr["AssessmentSection"].ToString();
                    parentNode.parentQuestionCode = Convert.ToDecimal(dr["ParentQuestionCode"]);
                    parentNode.shortName = dr["ShortName"].ToString();
                    var qry = dt.AsEnumerable().Where(x => x.Field<int>("ParentQuestionCode") == parentNode.QuestionCode)
                                                .Select(x => new { QuestionCode = x.Field<int>("QuestionCode"), AssessmentSection = x.Field<string>("AssessmentSection"), ShortName = x.Field<string>("ShortName") }).ToList();
                    parentNode.ChildQuestionNode = new List<QuestionNode>();
                    parentNode.ChildQuestionNode.Add(parentNode);
                    qtree.Add(parentNode);
                }
    
                    //    foreach (var item in qry)
                    //    {
                    //        QuestionNode qst = new QuestionNode();
                    //        qst.AssessmentSection = item.AssessmentSection;
                    //        qst.QuestionCode = item.QuestionCode;
                    //        qst.shortName = item.ShortName;
                    //        qst.ChildQuestionNode = null;
                    //        parentNode.ChildQuestionNode.Add(qst);
    
                    //    }
    
                    //    qtree.Add(parentNode);
                    //}
                
                    Action<QuestionNode> SetChildren = null;
                    SetChildren = parent =>
                    {
                        parent.ChildQuestionNode = qtree
                            .Where(childItem => childItem.parentQuestionCode == parent.QuestionCode)
                            .ToList();
    
                        //Recursively call the SetChildren method for each child.
                        parent.ChildQuestionNode
                            .ForEach(SetChildren);
                    };
    
                    //Initialize the hierarchical list to root level items
                    List<QuestionNode> hierarchicalItems = qtree
                        .Where(rootItem => rootItem.parentQuestionCode == 0)
                        .ToList();
    
                    //Call the SetChildren method to set the children on each root level item.
                    hierarchicalItems.ForEach(SetChildren);
    
                    foreach (QuestionNode qst in hierarchicalItems)
                    {
                        GetChildren(qst, 0, true, -1);
                    }
    
    
    
     private void GetChildren(QuestionNode parentNode, int level, bool useC1Way, int parentrow)
            {
    
                // add new row for this node
                int row;
                if (useC1Way == true)
                {
                    //This is the code by C1
                    // add new row for this node
                    row = grdData.Rows.Count;
                    grdData.Rows.Add();
                    grdData[row, 0] = parentNode.AssessmentSection;
                    if (parentNode.ChildQuestionNode == null)
                    {
                        grdData[row, 1] = "?";
                        grdData.SetCellStyle(row, 1, grdData.Styles["Data"]);
                    }
    
                    // make new row a node
                    grdData.Rows[row].IsNode = true;
                    grdData.Rows[row].Node.Level = level;
                }
                else
                {
                    //And this is my different version: at level 0, add a row. At child levels, insert "last child"
                    if (level == 0)
                    {
    
                        Row zeile = this.grdData.Rows.Add();
                        zeile.IsNode = true;
                        zeile.Node.Level = 0;
    
                        grdData[zeile.Index, 0] = parentNode.AssessmentSection;
    
                        //This also works...
                        //Node nodeGrid = grdData.Rows.AddNode(0);
                        //grdData[nodeGrid.Row.Index, 0] = node.Name;
                    }
                    else
                    {
                        //int row = grdData.Rows.Count;
                        //grdData.Rows.Add();
                        grdData.Rows[parentrow].Node.AddNode(NodeTypeEnum.LastChild, parentNode.AssessmentSection);
    
                    }
                    row = grdData.Rows.Count - 1;
                }
                //grdData[row, 0] = node.Name;
                if (parentNode.ChildQuestionNode == null)
                {
                    grdData[row, 1] ="?";
                    grdData.SetCellStyle(row, 1, grdData.Styles["Data"]);
                }
    
                // make new row a node
                //grdData.Rows[row].IsNode = true;
                //grdData.Rows[row].Node.Level = level;
    
                // if this node has children, get them as well
                if (parentNode.ChildQuestionNode != null  && parentNode.ChildQuestionNode.Count > 1)
                {
                    // recurse to get children
                    foreach (QuestionNode child in parentNode.ChildQuestionNode)
                        GetChildren(child, level + 1, useC1Way, row);
                }
            }

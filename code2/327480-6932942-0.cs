    Html.Telerik().TreeView() 
                .Name("TreeName") 
                .BindTo(Model, mappings =>  
                { 
                    mappings.For<SMTXEFMVCModel.Contract>(binding => binding 
                            .ItemDataBound((item, contract) => 
                            { 
                                item.Text = contract.Description;
    							item.SpriteCssClasses = ("icon-contracts");
                            }) 
                            .Children(contract => contract.Members)); 
                    mappings.For<SMTXEFMVCModel.Member>(binding => binding 
                            .ItemDataBound((item, member) => 
                            { 
                                item.Text = member.FirstName + " " + member.LastName;
    							item.SpriteCssClasses = ("icon-members");
                            }) 
                            .Children(member => member.Assessments)); 
                    mappings.For<MSMTXEFMVCModel.Assessments>(binding => binding 
                            .ItemDataBound((item, assessments) => 
                            { 
                                item.Text = assessments.AssessmentType;
    							...
                            }));
                }) 

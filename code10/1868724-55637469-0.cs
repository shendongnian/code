        private void GenerateWorksheetCommentsPart1Content(WorksheetCommentsPart worksheetCommentsPart1)
        {
            Comments comments1 = new Comments(){ MCAttributes = new MarkupCompatibilityAttributes(){ Ignorable = "xr" }  };
            comments1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            comments1.AddNamespaceDeclaration("xr", "http://schemas.microsoft.com/office/spreadsheetml/2014/revision");
            Authors authors1 = new Authors();
            Author author1 = new Author();
            author1.Text = "Hannen, Scott";
            authors1.Append(author1);
            CommentList commentList1 = new CommentList();
            Comment comment1 = new Comment(){ Reference = "B3", AuthorId = (UInt32Value)0U, ShapeId = (UInt32Value)0U };
            comment1.SetAttribute(new OpenXmlAttribute("xr", "uid", "http://schemas.microsoft.com/office/spreadsheetml/2014/revision", "{811649EF-4CB5-4311-BE14-228133003BE4}"));
            CommentText commentText1 = new CommentText();
            Run run1 = new Run();
            RunProperties runProperties1 = new RunProperties();
            FontSize fontSize3 = new FontSize(){ Val = 9D };
            Color color3 = new Color(){ Indexed = (UInt32Value)81U };
            RunFont runFont1 = new RunFont(){ Val = "Tahoma" };
            RunPropertyCharSet runPropertyCharSet1 = new RunPropertyCharSet(){ Val = 1 };
            runProperties1.Append(fontSize3);
            runProperties1.Append(color3);
            runProperties1.Append(runFont1);
            runProperties1.Append(runPropertyCharSet1);
            Text text1 = new Text(){ Space = SpaceProcessingModeValues.Preserve };
            text1.Text = "This is my comment!\nThis is line 2!\n";
            run1.Append(runProperties1);
            run1.Append(text1);
            commentText1.Append(run1);
            comment1.Append(commentText1);
            commentList1.Append(comment1);
            comments1.Append(authors1);
            comments1.Append(commentList1);
            worksheetCommentsPart1.Comments = comments1;
        }

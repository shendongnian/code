    public void TestCommentBox()
            {
                window.GoTo("mylocalurl");
                window.Link(Find.ById("popuplink.aspx")).ClickNoWait();
                HtmlDialog dialog = window.HtmlDialog(Find.ByTitle("TestPopup"));
                dialog.TextField(Find.ById("Txtcomments")).TypeText("Commmenttest!");
            }

    var columnRowHeader = browser.Div(Find.ById(listingId)).Element(Find.ByClass("x-grid3-header-inner", false));
            var gridBody = browser.Div(Find.ById(listingId)).Element(Find.ByClass("x-panel-body", false));
            var gridPanel = browser.Div(Find.ById(listingId));
            var columnHeaderToMove = browser.Div(Find.ById(listingId)).TableCell(l => l.Text == "Title").ChildWithTag("div", null);
            int CurrentX = this.helper.FindPosition(columnHeaderToMove)[0];
            int CurrentY = this.helper.FindPosition(columnHeaderToMove)[1];
            var mouseDownEvent = new NameValueCollection();
            mouseDownEvent.Add("button", "1");
            mouseDownEvent.Add("clientX", "459");
            mouseDownEvent.Add("clientY", "115");
            columnHeaderToMove.FireEventNoWait("onmousedown", mouseDownEvent);
            Thread.Sleep(500);
            var columnHeaderToMoveTo = browser.Div(Find.ById(listingId)).TableCell(l => l.Text == "Person Responsible");
            //int newX = this.helper.FindPosition(columnHeaderToMoveTo)[0];
            //int newY = this.helper.FindPosition(columnHeaderToMoveTo)[1];
            int newX = 670;
            var eventProperties = new NameValueCollection();
            eventProperties.Add("button", "1");
            eventProperties.Add("clientX", newX.ToString());
            eventProperties.Add("clientY", "115");
            
            columnHeaderToMove.FireEventNoWait("onmousemove", eventProperties);
            Thread.Sleep(1000);
            
            //mouse up
            var mouseUpEvent = new NameValueCollection();
            mouseUpEvent.Add("button", "1");
            mouseUpEvent.Add("clientX", newX.ToString());
            mouseUpEvent.Add("clientY", "115");
            columnHeaderToMoveTo.FireEventNoWait("onmouseup", mouseUpEvent);
            columnHeaderToMove.FireEventNoWait("onmouseup", mouseUpEvent);
            Thread.Sleep(2000);
            int finalX = this.helper.FindPosition(columnHeaderToMove)[0];
            Assert.IsTrue(finalX != CurrentX, "Left was {0} is now {1} should be {2}.", CurrentX, finalX, newX);

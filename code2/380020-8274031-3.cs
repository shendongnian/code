     [TestMethod]
        public void TestRichtTextBox()
        {
            RichTextBox rtb = new RichTextBox();
            rtb.AppendText("I am adding some texts to the richTextBox");
            
            int offset = 3;
            TextPointer beginningPointer = rtb.CaretPosition.GetPositionAtOffset(offset);
            TextPointer endPointer = rtb.CaretPosition.DocumentEnd;
            TextRange rtbText = new TextRange(beginningPointer, endPointer);
            Assert.IsTrue(rtbText.Text == "m adding some texts to the richTextBox\r\n");
            // Now we if we keep the same beggining offset but we change the end Offset to go backwards.
            beginningPointer = rtb.CaretPosition.GetPositionAtOffset(3);
            endPointer = rtb.CaretPosition; // this one is the beginning of the text
            rtbText = new TextRange(beginningPointer, endPointer);
            Assert.IsTrue(rtbText.Text == "I a");
            // Nowe we want to read from the back three characters.
            // so we set the end Point to DocumentEnd.
            rtb.CaretPosition = rtb.CaretPosition.DocumentEnd;
            beginningPointer = rtb.CaretPosition.GetPositionAtOffset(-offset);
            endPointer = rtb.CaretPosition; // we already set this one to the end document
            rtbText = new TextRange(beginningPointer, endPointer);
            Assert.IsTrue(rtbText.Text == "Box");
        }

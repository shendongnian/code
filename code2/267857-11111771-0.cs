    //Create the TableCell for the PowerPoint table you are building.
    A.TableCell tableCell3 = new A.TableCell();
    A.TextBody textBody5 = new A.TextBody();
    A.BodyProperties bodyProperties5 = new A.BodyProperties();//Created but not modified.
    A.ListStyle listStyle5 = new A.ListStyle();//Created but not modified.
    A.Paragraph paragraph5 = new A.Paragraph();
    
    //First Word: "Hello" with Font-Size 60x and Font-Color Green.
    A.Run run1 = new A.Run();
    A.RunProperties runProperties1 = new A.RunProperties() { Language = "en-US", FontSize = 6000, Dirty = false, SmartTagClean = false };//Set Font-Size to 60px.
    A.SolidFill solidFill1 = new A.SolidFill();
    A.RgbColorModelHex rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "00B050" };//Set Font-Color to Green (Hex "00B050").
    solidFill1.Append(rgbColorModelHex1);
    runProperties1.Append(solidFill1);
    A.Text text1 = new A.Text();
    text1.Text = "Hello";
    run1.Append(runProperties1);
    run1.Append(text1);
    
    //Second Word: "World" with Font-Size 60x and Font-Color Blue.
    A.Run run2 = new A.Run();
    A.RunProperties runProperties2 = new A.RunProperties() { Language = "en-US", FontSize = 6000, Dirty = false, SmartTagClean = false };//Set Font-Size to 60px.
    A.SolidFill solidFill2 = new A.SolidFill();
    A.RgbColorModelHex rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "0070C0" };//Set Font-Color to Blue (Hex "0070C0").
    solidFill2.Append(rgbColorModelHex2);
    runProperties2.Append(solidFill2);
    A.Text text2 = new A.Text();
    text2.Text = " World";
    run2.Append(runProperties2);
    run2.Append(text2);
    
    //This element specifies the text run properties that are to be used if another run is inserted after the last run specified.
    //This effectively saves the run property state so that it can be applied when the user enters additional text.
    //If this element is omitted, then the application can determine which default properties to apply.
    //It is recommended that this element be specified at the end of the list of text runs within the paragraph so that an orderly list is maintained.
    //  Source: http://msdn.microsoft.com/en-us/library/documentformat.openxml.drawing.endparagraphrunproperties.aspx
    //Set the default formatting for words entered after "Hello World" with Font-Size 60x and Font-Color Blue.
    A.EndParagraphRunProperties endParagraphRunProperties5 = new A.EndParagraphRunProperties() { Language = "en-US", FontSize = 6000, Dirty = false };//Set Font-Size to 60px.
    A.SolidFill solidFill3 = new A.SolidFill();
    A.RgbColorModelHex rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "0070C0" };//Set Font-Color to Blue (Hex "0070C0").
    solidFill3.Append(rgbColorModelHex3);
    endParagraphRunProperties5.Append(solidFill3);
    
    paragraph5.Append(run1);//Append Run: "Hello".
    paragraph5.Append(run2);//Append Run: " World".
    paragraph5.Append(endParagraphRunProperties5);//Append formmatting for any text the user may enter after the words "Hello World".
    textBody5.Append(bodyProperties5);//Created but not modified.
    textBody5.Append(listStyle5);//Created but not modified.
    textBody5.Append(paragraph5);//Append Paragraph: "Hello World"
    
    //TableCell Properties.  Set Background-Color to Red (Hex "FF0000").
    A.TableCellProperties tableCellProperties3 = new A.TableCellProperties();
    A.SolidFill solidFill4 = new A.SolidFill();
    A.RgbColorModelHex rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "FF0000" };//Red Background for Single TableCell.
    solidFill4.Append(rgbColorModelHex4);
    tableCellProperties3.Append(solidFill4);//Append Red Background.
    
    tableCell3.Append(textBody5);
    tableCell3.Append(tableCellProperties3);

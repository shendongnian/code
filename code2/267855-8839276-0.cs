    // Assume we are adding a A.TableCell to A.TableRow...
    A.TableCell tc = new A.TableCell(
    new A.TextBody(
    new A.BodyProperties(),
    new A.Paragraph(new A.Run( 
    // -> Add the RunProperties as additional Element to A.Run constructor:
    new A.RunProperties() { FontSize = 600 }, new A.Text("some text") ) ) ),
    new A.TableCellProperties() );
    // Now add the cell to a A.TableRow instance...

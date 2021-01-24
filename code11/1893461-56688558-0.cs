C#
public struct Entry
{
    public string TransactionID;
    public string Name;
    public string Amount;
    public string Output_Code;
}
Iterate through the file and create a list of `Entry` instances, one for each file line, and populate the data of each `Entry` instance with the contents of the line.  It looks like you can split the text line using white spaces as a delimiter and then further split each entry using `':'` as a delimiter.
Then, for each entry, you set the `Output_Code` during your processing phase.
C#
foreach(Entry entry in entrylist)
   entry.Output_Code = MyProcessingOfTheEntryFunction(entry);
Finally iterate through your list of entries and rewrite the entire file using the data in your Entry list.  (Making sure to correctly write the header and any line spacers, etc..)
C#
OpenFile();
WriteFileHeader();
foreach(Entry entry in entrylist)
{
   WriteLineSpacer();
   WriteEntryData(entry);
}
CloseFile();

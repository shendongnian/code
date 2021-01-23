    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Word = Microsoft.Office.Interop.Word;
    using Color = Microsoft.Office.Interop.Word.WdColor;
    
    namespace WordDocTesting
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void FindAndReplace(Word.Application WordApp,
                                        object findText,
                                        object replaceWithText,
                                        bool boldIt)
            {
                object missing = Type.Missing;
    
                object matchCase = true;
                object matchWholeWord = true;
                object matchWildCards = false;
                object matchSoundLike = false;
                object nmatchAllWordForms = false;
                object forward = true;
                object format = false;
                object matchKashida = false;
                object matchDiacritics = false;
                object matchAlefHamza = false;
                object matchControl = false;
                object read_only = false;
                object visible = true;
                object replace = 2;
                object wrap = 1;
    
    
                WordApp.Selection.Find.Execute(ref findText,
                                               ref matchCase,
                                               ref matchWholeWord,
                                               ref matchWildCards,
                                               ref matchSoundLike,
                                               ref nmatchAllWordForms,
                                               ref forward,
                                               ref wrap,
                                               ref format,
                                               /*ref replaceWithText,*/ ref missing,
                                               /*ref replace,*/         ref missing,
                                               ref matchKashida,
                                               ref matchDiacritics,
                                               ref matchAlefHamza,
                                               ref matchControl);
    
                    
                if (boldIt)
                {
                    WordApp.Application.Selection.Font.Bold = 1;
                }
    
                WordApp.Application.Selection.Font.Italic = 0;
                WordApp.Application.Selection.Font.Color = Color.wdColorBlack;
    
                WordApp.Application.Selection.Text = (string)replaceWithText; 
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Word.Application word = new Word.Application();
                Word.Document document = new Word.Document();
    
                // Define an object to pass to the word API for missing parameters
                object missing = Type.Missing;
    
                try
                {
                    // Everything that word accepts must be an object
                    object fileName = @"R:\Project\Proposals\TestMe.docx";
    
                    object readOnly = true;
                    document = word.Documents.Open(ref fileName, ref missing, ref readOnly,
                                                   ref missing, ref missing, ref missing,
                                                   ref missing, ref missing, ref missing, 
                                                   ref missing, ref missing, ref missing, 
                                                   ref missing, ref missing, ref missing,
                                                   ref missing);
    
                    document.Activate();
    
                    String propsalTitle = "Lorem ipsum dolor sit amet";
                    this.FindAndReplace(word, "Enter Proposal Title Here", propsalTitle, true);
    
                    string defaultTechDesc = "ENTER RELEVANT TECHNICAL INFORMATION ABOUT PROJECT HERE.  USE PICTURES WHEN AVAILABLE AND APPLICABLE.";
                    String techDesc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer tempor rutrum libero sed dapibus. Praesent vehicula mollis ultricies. Maecenas vulputate enim vitae nisi gravida euismod. Morbi aliquam lacus enim. Donec suscipit mi at sem mollis id gravida sapien tempor. Donec in sem at quam dignissim placerat et a urna. Maecenas nec tellus vel ipsum volutpat aliquet nec ut tortor. Nulla facilisi. Donec vel quam lectus, ac mattis sapien. Nullam a justo nisl, sit amet congue velit. Ut imperdiet, velit id luctus vulputate, augue libero consectetur eros, quis gravida quam orci ac lacus. Curabitur mollis, mi sit amet interdum feugiat, risus lacus dignissim metus, ut luctus nulla orci a ante. Nunc et turpis vel ipsum faucibus rhoncus eu eu velit. Sed interdum, magna sit amet porta euismod, orci felis tincidunt mauris, et iaculis ligula arcu molestie justo. Duis sollicitudin purus ut purus hendrerit adipiscing. Donec aliquam ultricies eros. ";
                    this.FindAndReplace(word, defaultTechDesc, techDesc, false);
    
                    String deliverables = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
                    this.FindAndReplace(word, "ENTER ALL ITEMS THAT WILL BE DELIVERD OVER PERIOD OF PERFORMANCE FOR THIS PROJECT.", deliverables, false);
    
                    String Contact = "Jenny";
                    this.FindAndReplace(word, "ENTER POINT OF CONTACT HERE", Contact, false);
    
                    String PocTitle = "ipsum";
                    this.FindAndReplace(word, "ENTER POC TITLE HERE", PocTitle, false);
    
                    String PocTeam = "dolor";
                    this.FindAndReplace(word, "ENTER POC TEAM NAME HERE", PocTeam, false);
    
                    String PocPhone = "867-5309";
                    this.FindAndReplace(word, "ENTER POC PHONE NUMBER HERE", PocPhone, false);
    
                    String PocEmail = "Jenny.G.Time@Sit.amet";
                    this.FindAndReplace(word, "ENTER POC EMAIL HERE", PocEmail, false);
    
                    // Tables
                    Word.Table table = document.Tables[1];
    
                    int x = 0;
                    double totalCost = 0;
                    Word.Row row;
                    for (int i = 1; i <= 10; i++)
                    {
                        x = i + 1;
                        row = table.Rows.Add(ref missing);
                        row.Cells[1].Range.Text = "Task New " + i;
                        row.Cells[2].Range.Text = String.Format("{0:C}", i);
                        table.Cell(x, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                        table.Cell(x, 1).Range.Font.Bold = 0;
                        table.Cell(x, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                        table.Cell(x, 2).Range.Font.Bold = 0;
                        totalCost = totalCost + i;
                    }
    
                    x = x + 1;
                    row = table.Rows.Add(ref missing);
                    row.Cells[1].Range.Text = "Total";
                    row.Cells[2].Range.Text = String.Format("{0:C}", totalCost);
                    table.Cell(x, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    table.Cell(x, 1).Range.Font.Bold = 1;
                    table.Cell(x, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    table.Cell(x, 2).Range.Font.Bold = 1;
    
                    object newFileName = @"R:\Project\Proposals\TestMe2.docx";
    
                    document.SaveAs(ref newFileName,
                                    ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing);
                }
    
                catch (Exception ex)
                {
                    // Message here
                }
                finally
                {
                    document.Close(ref missing, 
                                   ref missing, 
                                   ref missing);
    
                    word.Application.Quit(ref missing, 
                                          ref missing, 
                                          ref missing);
                }
            }
        }
    }

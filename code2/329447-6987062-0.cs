                // Splits the RichTextBox up so the numbers can be formatted properly.
                String[] myXLines = calculateXRichTextBox.Text.Split('\n');
                String[] myYLines = calculateYRichTextBox.Text.Split('\n');
                int counterX = 0;
                int counterY = 0;
                foreach (string decimalXLines in myXLines)
                {
                    if (counterX == 0)
                        removedXDecimalRichTextBox.AppendText(Math.Round(Convert.ToDouble(decimalXLines), 2) + "");
                    if (decimalXLines != "" && counterX != 0)
                    {
                        removedXDecimalRichTextBox.AppendText("\n");
                        removedXDecimalRichTextBox.AppendText(Math.Round(Convert.ToDouble(decimalXLines), 2) + "");
                    }
                    counterX++;
                }
                foreach (string decimalYLines in myYLines)
                {
                    if (counterY == 0)
                        removedYDecimalRichTextBox.AppendText(Math.Round(Convert.ToDouble(decimalYLines), 2) + "");
                    if (decimalYLines != "" && counterY != 0)
                    {
                        removedYDecimalRichTextBox.AppendText("\n");
                        removedYDecimalRichTextBox.AppendText(Math.Round(Convert.ToDouble(decimalYLines), 2) + "");
                    }
                    counterY++;
                }

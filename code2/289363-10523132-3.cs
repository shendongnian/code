    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace WindowsFormsApplication1
    {
        class clsMonthCalendarBehavior
        {
            private bool manualDateTimeIsDone
            {
                get
                {
                    return (SetDateTimeManual(this._dateTimeInput.Text));
                }
            }
    
            private static DateTime dateTimeManual;
    
            //Determine if the user inserting a correctly date and time
            internal static bool SetDateTimeManual(string inputReference)
            {
                DateTime newDateTime = new DateTime(2000, 1, 1, 0, 0, 0);
    
                bool isDateTime = DateTime.TryParse(inputReference, out newDateTime);
    
                if (isDateTime)
                    dateTimeManual = newDateTime;
    
                return (isDateTime ? true : false);
            }
    
            private MaskedTextBox _dateTimeInput;
    
            internal void ShowCalendar(MaskedTextBox dateTimeInput,
                                       bool showNumbersOfWeeks,
                                       bool principalFormIsTopMost)
            {
                MonthCalendar monthCalendarCustomized = new MonthCalendar();
                Panel popupPanel = new Panel();
                Form floatingForm = new Form();
    
                this._dateTimeInput = dateTimeInput;
    
                //OPTIONAL: Show week numbers
                monthCalendarCustomized.ShowWeekNumbers = showNumbersOfWeeks;
                monthCalendarCustomized.MaxSelectionCount = 1;
    
                if (manualDateTimeIsDone)
                    monthCalendarCustomized.SetDate(dateTimeManual); //User, date and time selected
                else
                    monthCalendarCustomized.SetDate(DateTime.Now); //System, actual date and time
                
                monthCalendarCustomized.DateSelected += new DateRangeEventHandler(DateSelected);
                monthCalendarCustomized.KeyDown +=new KeyEventHandler(KeyDown);
    
                monthCalendarCustomized.ShowToday = true;
    
                //IDEA: bolded dates about references, etc.
                monthCalendarCustomized.BoldedDates = new DateTime[]
                {
                    DateTime.Today.AddDays(1),
                    DateTime.Today.AddDays(2),
                    DateTime.Today.AddDays(7),
                    DateTime.Today.AddDays(31),
                    DateTime.Today.AddDays(10)
                };
    
                popupPanel.BorderStyle = BorderStyle.FixedSingle;
                
                popupPanel.Controls.Add(monthCalendarCustomized);
    
                floatingForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                floatingForm.ShowInTaskbar = false;
               
                floatingForm.Location = Control.MousePosition;
                floatingForm.StartPosition = FormStartPosition.Manual;
                
                floatingForm.Controls.Add(popupPanel);
                floatingForm.Deactivate += delegate { floatingForm.Close(); };
    
                //NOTE: if principal from is topmost, cannot show in front "floatingForm" with calendar 
                //      this option  fix the situation.
                floatingForm.TopMost = principalFormIsTopMost;
                
                //NOTE: set initial size of controls.
                floatingForm.Size = popupPanel.Size = new Size(20, 20);
    
                floatingForm.Show();
    
                popupPanel.Size = floatingForm.Size = monthCalendarCustomized.Size;
    
                popupPanel.Width = popupPanel.Width + 2;
                popupPanel.Height = popupPanel.Height + 2;
    
                floatingForm.Width = floatingForm.Width + 3;
                floatingForm.Height = floatingForm.Height + 3;
            }
    
            void DateSelected(object sender, DateRangeEventArgs e)
            {
                //Set data selected with culture info mask
                this._dateTimeInput.Text = SetTimeValue(e.Start).ToString("MM/dd/yyyy HH:mm");
    
                CloseFloatingForm(sender);
            }
            
            private static void CloseFloatingForm(object sender)
            {
                MonthCalendar monthCalendarCustomized = (MonthCalendar)sender;
                Form floatingForm = monthCalendarCustomized.FindForm();
    
                monthCalendarCustomized.Parent.Controls.Remove(monthCalendarCustomized);
    
                floatingForm.Close();
            }
    
            private DateTime SetTimeValue(DateTime selectedDateTime)
            {
                //Recovery time of after selection, because when user select a new date
                //Month Calendar reset the time
                if (manualDateTimeIsDone)
                {
                    TimeSpan addTimeValue = new TimeSpan(dateTimeManual.Hour,
                                                         dateTimeManual.Minute,
                                                         dateTimeManual.Second);
    
                    selectedDateTime = selectedDateTime.Add(addTimeValue);
                }
    
                return (selectedDateTime);
            }
    
            private void KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                    CloseFloatingForm(sender);                
            }
        }
    }

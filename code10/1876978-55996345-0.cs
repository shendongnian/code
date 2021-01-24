     using System;
     using System.Collections.Generic;
     using System.Drawing;
     using System.Windows.Forms;
     private void NotificationsForm_Load(object sender, EventArgs e)
        {
            PopulateUsersGroupsList(); // Used to create the list of User Groups & User Accounts when the form opens.
            log.Info("NotificationsForm Opened");
        }
        // Create an image list that will be used for the combobox icons
        readonly static ImageList imageListEmailRecipients = new ImageList();
        // Create an List that will be used to store the user account and user group names from the two different data tables.
        public static readonly List<KeyValuePair<string, string>> emailRecipientsUserList = new List<KeyValuePair<string, string>>();
        /// <summary>
        /// This method is used to create a list to hold the values pulled from two different data tables.
        /// The information pulled provides the list with the names of the User Groups & User Accounts.
        /// Note: When the Windows Form closes, the closing method runs the command 'emailRecipientsUserList.Clear()'
        /// in order to ensure that the list is cleared and does not continue to build up with dulicate entries each
        /// time the form is opened.
        /// </summary>
        private void PopulateUsersGroupsList()
        {
            // Add the two images to the image list, images are loaded from the properties resources folder.
            // These images will be used as icons to display in the combobox.
            imageListEmailRecipients.Images.Add((Image)(new Bitmap(Properties.Resources.UserGroup2)));
            imageListEmailRecipients.Images.Add((Image)(new Bitmap(Properties.Resources.UserAccount)));
            // Add a default string to the list for the combobox default value, prompting the user to make their selection
            // before the open up the dropdown combobox.
            emailRecipientsUserList.Add(new KeyValuePair<string, string>("", "--Select--"));
            // Add each User Group from the data table to the list. KeyValuePairs are used so we can differentiate
            // between the User Groups list and User Accounts list.
            for (int i = 0; i < DB_UserGroups.userGroupsDataTable.Rows.Count; i++)
            {
                emailRecipientsUserList.Add(new KeyValuePair<string, string>("UserGroup", DB_UserGroups.userGroupsDataTable.Rows[i]["UserGroup"].ToString()));
            }
            // Add each User Account from the data table to the list. KeyValuePairs are used so we can differentiate
            // between the User Groups list and User Accounts list.
            for (int i = 0; i < DB_Users.userAccountsDataTable.Rows.Count; i++)
            {
                //emailRecipientsUserList.Add(DB_Users.userAccountsDataTable.Rows[i]["Username"].ToString());
                emailRecipientsUserList.Add(new KeyValuePair<string, string>("Username", DB_Users.userAccountsDataTable.Rows[i]["Username"].ToString()));
            }
            // Run the method below that will populate the combobox with the User Groups & User Accounts from the list.
            AddUsersGroupsComboboxPopulate();
        }
        /// <summary>
        /// Method used to populate the combobox using the 'emailRecipientsUserList' created from the method above. 
        /// </summary>
        private void AddUsersGroupsComboboxPopulate()
        {
            // Clear the comobox before re-populating.
            AddUserGroupCombobox.Items.Clear();
            // Map the combobox's data source to the 'emailRecipientsUserList' source.
            this.AddUserGroupCombobox.DataSource = emailRecipientsUserList;
            // Confirure the combobox to the show the 'Value' portion ONLY from the KeyValuePair 
            // value set found in the 'emailRecipientsUserList'.
            this.AddUserGroupCombobox.DisplayMember = "Value";
            // Configure the combobox to utilise the Key from the 'emailRecipientsUserList' as its member value.
            this.AddUserGroupCombobox.ValueMember = "Key";
            // Set the combobox to owner draw mode - otherwise you cannot change the output style to your own format.
            AddUserGroupCombobox.DrawMode = DrawMode.OwnerDrawFixed;
            // Instruct the combobox to draw itself using the 'AddUserGroupCombobox_DrawItem' method below.
            AddUserGroupCombobox.DrawItem += AddUserGroupCombobox_DrawItem;
            // Set the default height for each of the items displayed in the combobox.
            AddUserGroupCombobox.ItemHeight = 20;
        }
        // Mouse index used to reference the position of the cursor when navigating up and down the combobox list.
        private readonly int _MouseIndex = -1;
        /// <summary>
        /// This method is used to draw the items from the 'emailRecipientsUserList' into the combobox, 
        /// using an owner draw custom format so we can show the the User Group & User
        /// Account icons adjacent their relevant names in the combobox list.
        /// 
        /// In the method above, we created the 'emailRecipientsUserList' that contains data columns
        /// from two different data tables, the first datatable holds the names of the User Groups and the second
        /// holds the User Accounts. We're utilizing the KeyValuePair in order to provide a
        /// means of applying some logic to the population of our combobox in order to differentiate 
        /// between a User Group and a User Account. This allows us to dynamically
        /// assign the relevant icon display, adjacent each of the items in the combobox list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserGroupCombobox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Set the textBrush color to Windows Text.
            Brush textBrush = SystemBrushes.WindowText;
            if (e.Index > -1)
            {
                // Highlight the combobox item when the mouse cursor hovers over the item in the dropdown list.
                if (e.Index == _MouseIndex)
                {
                    e.Graphics.FillRectangle(SystemBrushes.HotTrack, e.Bounds);
                    textBrush = SystemBrushes.HighlightText;
                }
                else
                {
                    // Highlight the combobox item when slected in the dropdown list.
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                        textBrush = SystemBrushes.HighlightText;
                    }
                    else
                    {
                        // Restore background colour to deafult when the mouse leaves the item.
                        e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                    }
                }
                // Draw the string i.e populate the combobox with the list of the text names
                // for the User groups & User Accounts
                e.Graphics.DrawString(emailRecipientsUserList[e.Index].Value.ToString(), e.Font, textBrush, e.Bounds.Left + 20, e.Bounds.Top);
                // IF Statements below are used to determine which icon to display in the drop down list, depending on
                // whether the comboxo item is a User Group or User Account name.
                if (emailRecipientsUserList[e.Index].Key == "UserGroup")
                {
                    // Image list index '0' represents the icon image for the User Group.
                    e.Graphics.DrawImage(imageListEmailRecipients.Images[0], e.Bounds.Left, e.Bounds.Top);
                }
                if (emailRecipientsUserList[e.Index].Key == "Username")
                {
                    // Image list index '0' represents the icon image for the User Account.
                    e.Graphics.DrawImage(imageListEmailRecipients.Images[1], e.Bounds.Left, e.Bounds.Top);
                }
            }
        }

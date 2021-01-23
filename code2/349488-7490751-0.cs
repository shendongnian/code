    using PDMWorks.Interop.pdmworks;//PDM Reference
        public interface IPDMWConnection { }
        public interface IPDMWDocuments { }
        public interface IPDMWDocument { }
        private void button10_Click(object sender, EventArgs e) //Check Drawing Into PDM Change State "Roll to Standard"
        {
            var filename = textBox1.Text + ".slddrw";
            var project = "MLD028D";
            var number = "1";
            var description = "Configured Actuator Drawing";
            var note = "Configured by Actuator Generator";
            var revision = "--";
            var lifecycle = "Configured";
            bool retainOwnership = false;
            object references = textBox1.Text + "sldasm";
            //CheckIn Drawing to PDM
            PDMWDocument CheckIn(
            filename, //filename- Name of the closed document to check in
            project, //project- Name of the project to which the document belongs
            number, //Number Document number
            description, //Description Document description
            note, //note Document notes
            //PDMWRevisionOptionType i_revOption, //i_revOption - Revision option as defined in PDMWRevisionOptionType (see Remarks)
            revision, //Revision - Document revision
            lifecycle, //lifecycle - Document lifecycle status
            retainOwnership, //RetainOwnership - (bool false)True to retain ownership of the document in the vault, false to not
            references //References - Array of the full paths and filenames of any referenced documents to check in (see Remarks)
            );
            MessageBox.Show(textBox1.Text + " Drawing and Assembly Checked-In");
        }

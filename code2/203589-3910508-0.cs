        /// <summary>
        /// Saves the editor.
        /// </summary>
        private void SaveEditor()
        {
            if(Mode == ScaffoldMode.Edit)
                UpdateRecord(PrimaryKeyControlValue);
            else
                InsertRecord();
            SaveManyToMany();
            AfterTheSave();
            if(ReturnOnSave)
                BuildWithModeChange(ScaffoldMode.List);
        }
        public virtual void AfterTheSave()
        {
        }

        private void LabelChangeset(string fileLabel, Changeset changeset)
        {
            VersionControlLabel vcl = new VersionControlLabel(vcServer, fileLabel, null, cbProjects.SelectedItem.ToString(), "Autogen label.");
            LabelItemSpec[] itemSpecs = new LabelItemSpec[changeset.Changes.Length];
            string ver = string.Format("C{0}", changeset.ChangesetId);
            VersionSpec fileVersion = VersionSpec.ParseSingleSpec(ver, null);
            int index = 0;
            foreach (Change c in changeset.Changes)
            {
                itemSpecs[index++] = new LabelItemSpec(new ItemSpec(c.Item.ServerItem, RecursionType.None), fileVersion, false);
            }
            LabelResult[] results = vcServer.CreateLabel(vcl, itemSpecs, LabelChildOption.Replace);
        }

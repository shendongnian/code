            for (int i = 0; i < AudioCdWriter.FileCount; ++i) {
                var item = new ListViewDataItem(i.ToString());
                item.SubItems.Add(AudioCdWriter.TrackLength((short)i).ToString());
                item.SubItems.Add(AudioCdWriter.file[(short)i]);
                lvwAudioFiles.Items.Add(item);
            }

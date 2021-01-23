                    this._lastMicVol = tag.Volume;
                    this.toolStripMuteButton.Image = global::Properties.Resources.microphone2;
                    tag.Volume = 0;
                }
                else
                {
                    this.toolStripMuteButton.Image = global::Properties.Resources.microphone1;
                    tag.Volume = this._lastMicVol;
                }`

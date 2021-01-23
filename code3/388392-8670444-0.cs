            // ------ code piece 
            /// <summary>
            /// Gets the available voice.
            /// </summary>
            /// <returns>New SourceVoice object is always returned. </returns>
            private SourceVoice GetAvailableVoice()
            {
                return new SourceVoice(_player.GetDevice(), _stream.Format);
            }
            /// <summary>
            /// Plays this sound asynchronously.
            /// </summary>
            public void Play()
            {
                // get the next available voice
                var voice = GetAvailableVoice();
                if (voice != null)
                {
                    // submit new buffer and start playing.
                    voice.FlushSourceBuffers();
                    voice.SubmitSourceBuffer(_buffer);
                    voice.Start();
                }
            }

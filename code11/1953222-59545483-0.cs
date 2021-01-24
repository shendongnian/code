cs
 DetectIntentResponse response = new DetectIntentResponse();
            var queryAudio = new InputAudioConfig
            {
                LanguageCode = LanguageCode,
                ModelVariant = SpeechModelVariant.Unspecified,
            };
            QueryInput queryInput = new QueryInput
            {
                AudioConfig = queryAudio,
            };
                var filename = "fileName".wav";
                // userAudioInput is the .AAC string URL 
                // creating and saving the wav format from AAC
                using (var reader = new MediaFoundationReader(userAudioInput))
                {
                    Directory.CreateDirectory(path);
                    WaveFileWriter.CreateWaveFile(path + "/" + filename, reader);
                }
                // Reading the previously saved wav file
                byte[] inputAudio = File.ReadAllBytes(path + "/" + filename);
                DetectIntentRequest detectIntentRequest = new DetectIntentRequest
                {
                    //InputAudio = Google.Protobuf.ByteString.CopyFrom(ReadFully(outputStreamMono)),
                    InputAudio = Google.Protobuf.ByteString.CopyFrom(inputAudio),
                    QueryInput = queryInput,
                    Session = "projects/" + _sessionName.ProjectId + "/agent/sessions/" + _sessionName.SessionId
                };
                // Make the request
                response = await _sessionsClient.DetectIntentAsync(detectIntentRequest);

c#
public async Task HandleMessages() {
        try {
            using (var ms = new MemoryStream()) {
                while (ws.State == WebSocketState.Open) {
                    WebSocketReceiveResult result;
                    do {
                        var messageBuffer = WebSocket.CreateClientBuffer(1024, 16);
                        result = await ws.ReceiveAsync(messageBuffer, CancellationToken.None);
                        ms.Write(messageBuffer.Array, messageBuffer.Offset, result.Count);
                    }
                    while (!result.EndOfMessage);
                    if (result.MessageType == WebSocketMessageType.Text) {
                        var msgString = Encoding.UTF8.GetString(ms.ToArray());
                        var message = JsonConvert.DeserializeObject<Dictionary<String, String>>(msgString);
                        if (message["roomCode"].ToLower() == RoomCode.ToLower()) {
                            Debug.Log("[WS] Got a message of type " + message["messageType"]);
                            // Message was intended for us!
                            switch (message["messageType"]) {
                                // handle messages here, unimportant to stackoverflow
                            }
                        }
                    }
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Position = 0;
                }
            }
        } catch (InvalidOperationException) {
            Debug.Log("[WS] Tried to receive message while already reading one.");
        }
    }
Once I configured the server to actually broadcast the messages I thought I was broadcasting (iterate over all clients and send the message), it now will read multiple messages. Thanks again for the help and hopefully this will help others in the future who are new to websockets have something to check for

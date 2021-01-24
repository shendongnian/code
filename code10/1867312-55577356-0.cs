     //Create a new MQTT client
                var mqttClient = new MqttFactory().CreateManagedMqttClient();
    
                var caCert = new X509Certificate(@"C:\cert.pfx", "psw");
                var url = "myurl.com";
                var username = "user";
                var psw = "user";
                var port = 8885;
    
                var options = new ManagedMqttClientOptionsBuilder()
                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(30))
                    .WithClientOptions(new MqttClientOptionsBuilder()
                        .WithClientId(Guid.NewGuid().ToString())
                        .WithTcpServer(url, port)
                        .WithCredentials(username, psw)
                        .WithTls(new MqttClientOptionsBuilderTlsParameters()
                        {
                            AllowUntrustedCertificates = false,
                            UseTls = true,
                            Certificates = new List<byte[]> { new X509Certificate2(caCert).Export(X509ContentType.Cert) },
                            CertificateValidationCallback = delegate { return true; },
                            IgnoreCertificateChainErrors = false,
                            IgnoreCertificateRevocationErrors = false
                        })
                        .WithCleanSession()
                        .WithProtocolVersion(MQTTnet.Serializer.MqttProtocolVersion.V311)
                        .Build())
                    .Build();
               
    
                // Connecting
                await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("$share:mygroup:/mytopic").Build());
                await mqttClient.StartAsync(options);

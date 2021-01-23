            var messages = pictureBox1MouseDragMessages
                .Merge(button1ClickMessages);
            // Add a subscription to display the
            // merged messages in the label
            subscriptions.Add(
                messages
                    .Subscribe(m => label1.Text = m));
        }
    }

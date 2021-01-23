    bool IsIncomingAVCall(Conversation conversation)
    {
        // Test to see if the call contains the AV modality
        bool containsAVModality = conversation.Modalities.ContainsKey(ModalityTypes.AudioVideo);
        if (containsAVModality)
        {
            // Get the state of the AV modality
            var state = conversation.Modalities[ModalityTypes.AudioVideo].State;
            // 'Notified' means the call is incoming
            if (state == ModalityState.Notified) return true;
        }
        return false;
    }

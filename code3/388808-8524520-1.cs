    sequences.Include.....Where(s => s.ID == schedule.SequenceID).SelectMany(s => s.Events).SelectMany(e => e.EventFrames).SelectMany(ef => ef.EventFramePlugins)
        .SelectMany(efp => efp.EventFramePluginContents).SelectMany(efpc => efpc.ClientContentItems).
        SelectMany(cci => cci.ClientContentItemElemts).Where(ccie => ccie.ClientContentItemElementId == myValue).
        Select(
            ccie =>
            new
                {
                    ccie,
                    ccie.ClientContentItem.EventFramePluginContentItem.EventFramePlugin.EventFrame.Event.
                Sequence
                });  

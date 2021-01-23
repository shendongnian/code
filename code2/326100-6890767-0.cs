    using Splicer;
    using Splicer.Timeline;
    using Splicer.Renderer;
    string firstVideoFilePath = @"C:\first.avi";
    string secondVideoFilePath = @"C:\second.avi";
    string outputVideoPath = @"C:\output.avi";
    using (ITimeline timeline = new DefaultTimeline())
    {
        IGroup group = timeline.AddVideoGroup(32, 720, 576);
        var firstVideoClip = group.AddTrack().AddVideo(firstVideoFilePath);
        var secondVideoClip = group.AddTrack().AddVideo(secondVideoFilePath, firstVideoClip.Duration);
        using (AviFileRenderer renderer = new AviFileRenderer(timeline, outputVideoPath))
        {
            renderer.Render();
        }
    }

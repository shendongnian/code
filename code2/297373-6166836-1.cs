    /* Example assumes your controls are in the best possible
       order for this technique. If they were mostly at the end
       with a few in the middle a modified version of this
       could still work. */
    int i = Controls.Count - 1;
    bool stillRemoving = true;
    SuspendLayout();
    while (stillRemoving && i >= 0){
        Control c = Controls[i];
        if (ShouldRemoveControl(c)){
            UnhookEvents(c);
            Controls.RemoveAt(i);
            i--;
        }else{
            stillRemoving = false;
        }
    }
    ResumeLayout();

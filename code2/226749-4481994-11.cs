    open MusicTheory
    open Aux
    open ScaleIntervals
    
    let testScaleNoteHeuristics intervals =
        let printNotes (noteName:string) =
            printfn "%A" (Scale(intervals).ToString(noteName))
    
        noteNames
        |> Seq.iter printNotes
    //> testScaleNoteHeuristics Mode.ionian;;
    //"[B#; D; E; F; G; A; B; B#]"
    //"[C; D; E; F; G; A; B; C]"
    //"[C#; D#; E#; F#; G#; A#; B#; C#]"
    //"[Db; Eb; F; Gb; Ab; Bb; C; Db]"
    //"[D; E; F#; G; A; B; C#; D]"
    //"[D#; E#; G; Ab; Bb; C; D; D#]"
    //"[Eb; F; G; Ab; Bb; C; D; Eb]"
    //"[E; F#; G#; A; B; C#; D#; E]"
    //"[Fb; Gb; Ab; A; B; C#; D#; Fb]"
    //"[E#; G; A; Bb; C; D; E; E#]"
    //"[F; G; A; Bb; C; D; E; F]"
    //"[F#; G#; A#; B; C#; D#; E#; F#]"
    //"[Gb; Ab; Bb; Cb; Db; Eb; F; Gb]"
    //"[G; A; B; C; D; E; F#; G]"
    //"[G#; A#; B#; C#; D#; E#; G; G#]"
    //"[Ab; Bb; C; Db; Eb; F; G; Ab]"
    //"[A; B; C#; D; E; F#; G#; A]"
    //"[A#; B#; D; Eb; F; G; A; A#]"
    //"[Bb; C; D; Eb; F; G; A; Bb]"
    //"[B; C#; D#; E; F#; G#; A#; B]"
    //"[Cb; Db; Eb; Fb; Gb; Ab; Bb; Cb]"
    //val it : unit = ()

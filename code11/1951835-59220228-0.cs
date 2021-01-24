    namespace StandardNoteReceiverService
    {
        public abstract class NoteReceiverHandler : BaseIntegrationService
        {
            private Vendor.Sys.Services.ReceiveNoteData _ReceiveNoteData;
            public NoteReceiverHandler() { }
            public NoteReceiverHandler(Vendor.Sys.Services.ReceiveNoteData receiveNoteData)
            {
                this._ReceiveNoteData = receiveNoteData;
            }
            public abstract Vendor.Sys.Services.ReceiveNoteResponse TakeAction(Vendor.Sys.Services.ReceiveNoteData receiveNoteData);
        }
        public class Sys2Handler : NoteReceiverHandler
        {
            public override Services.ReceiveNoteResponse TakeAction(Services.ReceiveNoteData receiveNoteData)
            {
                throw new NotImplementedException();
            }
        }
    }
